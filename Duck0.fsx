type Duck () =
  override d.ToString() = "Duck"

let (|WalksLikeDuckAndQuacksLikeDuck|_|) : obj -> Option<Duck> =
  function
  | :? Duck as duck -> Some duck
  | _ -> None

let doit =
  function
    // If it
  | WalksLikeDuckAndQuacksLikeDuck duck ->
    // then
    printfn "It's a duck: %O" duck
  | _ ->
    printfn "It's not a duck!"

new Duck() |> doit
"Duck" |> doit