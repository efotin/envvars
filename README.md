Simple F# type provider for environment variables.

```
#!text
Microsoft (R) F# Interactive version 11.0.60610.1
Copyright (c) Microsoft Corporation. All Rights Reserved.

For help type #help;;

> #r @"bin\Debug\EnvVars.dll"

open FSharp.Environment

EnvVars.ALLUSERSPROFILE;;

--> Referenced 'bin\Debug\EnvVars.dll'


val it : string = "C:\ProgramData"

>
```
[Usage demo](envvars/wiki/Usage)