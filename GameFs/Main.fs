namespace GameFs

open Godot

type MainData = {
    mutable level: int;
    mutable score: int;
    mutable time_left: int;
    mutable screensize: Vector2;
    mutable playing: bool;
}

type Main() as this =
    inherit Node()
    
    let player = lazy(
        this.GetNode(new NodePath("Player")) 
        :?> AnimatedSprite
    )

    member this.getScreensize : Vector2 =
        let screendelay = lazy(
            this.GetViewport().GetVisibleRect().Size
        )
        screendelay.Value

    member this.spawnCoin (coin: ref<PackedScene>)(container: ref<Node>) =
        for i in 1 .. 1 .. 4 do
            coin.Value.Instance() |> container.Value.AddChild

    member this.INIT : MainData = {level=0;score=0;time_left=0;playing=false;screensize=new Vector2()}