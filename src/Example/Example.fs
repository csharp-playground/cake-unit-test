module Example

open FSharp.Data
open FsUnit
open NUnit.Framework

type Simple = FSharp.Data.JsonProvider<""" { "name":"John", "age":94 } """>
let simple = Simple.Parse(""" { "name":"Tomas", "age":4 } """)

[<Test>]
let shouldCheckEquality() =
    1 + 1 |> should equal 2

[<Test>]
let fail() =
    1 + 1 |> should equal 0

[<Test>]
let hello() =
    "Hello" |> should equal "Hello"

(*
[<EntryPoint>]
let main argv =
    printfn "%A" argv
    printfn "%A" simple
    0 // return an integer exit code
*)