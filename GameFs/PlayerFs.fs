namespace GameFs

open Godot

type Facing = Up | Down | Right | Left

module PlayerFs =

    [<Signal>]
    type pickup = delegate of unit -> unit

    type Class() as this =
        inherit Area2D()

        [<Export>]
        let velocity = 200.f

        [<Export>]
        let direction = Right

        let ui = lazy(
            this.GetNode(new NodePath("Rubah")) 
            :?> AnimatedSprite
        )

        let anim state =
            if not (ui.Value.IsPlaying())
            then ui.Value.Play(state)

        let check input =
            if Input.IsActionPressed(input) then 1.0f else 0.0f

        let OnPlayerEnteredArea(area: Node) =
            if(area.IsInGroup("coins")) then this.EmitSignal("coins")
            else if (area.IsInGroup("obstacle")) then this.EmitSignal("hurt")
        
        override this._Process(delta) =
            let movement = new Vector2(
                check "ui_right" - check "ui_left",
                check "ui_down" - check "ui_up"
            )

            GD.Print("x: %.4f y: %.4f", movement.x,movement.y)

            this.Translate(movement.Normalized() * velocity * delta)

            let isMoving = movement <> new Vector2() in
            if isMoving then anim "run" else ui.Value.Stop()