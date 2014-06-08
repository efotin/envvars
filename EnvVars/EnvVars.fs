module FSharp.Environment.NamespaceProvider

open System
open System.Linq
open System.Collections
open System.Reflection
open Microsoft.FSharp.Core.CompilerServices
open ProviderImplementation.ProvidedTypes

[<TypeProvider>]
type EnvVarsProvider() as __ =
    inherit TypeProviderForNamespaces()

    [<Literal>]
    let ns = "FSharp.Environment"
    let asm = Assembly.GetExecutingAssembly()

    let createTypes () =
        let myType = ProvidedTypeDefinition (asm, ns, "EnvVars", Some typeof<obj>)

        let envVars = Environment.GetEnvironmentVariables().Cast<DictionaryEntry>()
        let props =
            envVars
            |> Seq.map (fun entry ->
                let key = entry.Key :?> string
                let value = entry.Value :?> string
                ProvidedProperty(key, typeof<string>, IsStatic = true, GetterCode = (fun args -> <@@ value @@>)))
            |> Seq.toList

        myType.AddMembers props

        [myType]

    do
        __.AddNamespace (ns, createTypes())

[<assembly: TypeProviderAssembly()>]
do()
