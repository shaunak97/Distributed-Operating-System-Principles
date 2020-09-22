#time "on"

#r "nuget:Akka.Fsharp"
#r "nuget:Akka.Testkit"

open System
open System.Diagnostics
open Akka.Actor
open Akka.Configuration
open Akka.FSharp
open Akka.TestKit

//Code to compute CPU Time and Real Time
let coreCount = Environment.ProcessorCount
let timer = Stopwatch()
timer.Start()
let pId = Process.GetCurrentProcess()
let cpu_time_stamp = pId.TotalProcessorTime

//Module to check if the sequence of numbers adds up to form a perfect square
module perfSqCheck=

    let isPerfSq s k=
       
        //Converting Received values to Int64 type
        let s1:int64= int64 s
        let k1:int64= int64 k
        
        let list1 = [s1..s1+k1-int64(1)]
        let list2 = list1 |> List.map (fun x -> (x * x)) 

        //Receiving sum of squares of that range
        let sum = List.sum list2

        let fsum = float(sum)
        let sqrtsum = sqrt fsum
        let t = truncate sqrtsum
        
        //Checking if it is a perfect square
        if  t=sqrtsum then
            true
        else
            false

//Module to count the number of actors that need to be spawned by the boss
module actorCount=

    let no_of_actors n=
        if n>1000  then
            1000
        else
            n

//Mainmodule that spawns the boss and various actors 
module mainModule=

        //Receiving input from user and storing it in final and k
        let args : string array = fsi.CommandLineArgs |> Array.tail
        let final=args.[0] |> int
        let k=args.[1] |> int
        
        let system = ActorSystem.Create("FSharp")
        
        //Defining the child actor and it's role
        type child(name) =
            inherit Actor()

            override x.OnReceive message =
                match message with
                | :? string as msg ->
                    let msgArray=msg.Split [|' '|]
                    let start=msgArray.[0] |> int
                    let k=msgArray.[1] |> int
                    let ans=perfSqCheck.isPerfSq start k
                    if ans=true then
                        printfn"%A\n"start
                   
                | _ ->  failwith "unknown message"
                
        //Defining the boss actor
        type boss =
            inherit Actor

            override x.OnReceive message =
                match message with
                | :? string as msg ->
                    let msgArray=msg.Split [|' '|]
                    let final=msgArray.[0] |> int
                    let k=msgArray.[1] |> int
                    let totActors = actorCount.no_of_actors final 
                    
                    //Spawning various child Actors depending on the input
                    let Childs =  
                        [0 .. totActors]
                        |> List.map(fun id ->   let properties = [| string(id) :> obj |]
                                                system.ActorOf(Props(typedefof<child>, properties)))

                    //Scheduling the messages to the various Child Actors
                    let maxActors=1000
                    let totalResendsD= ceil(double final/double maxActors)
                    let totalResends:int= int totalResendsD
                    
                    for i in [0 .. totalResends] do
                        let start=i*maxActors
                        for j in [1..maxActors] do
                            let cur = start+j
                            //Sending the message to the child Actors
                            if(cur<=final ) then
                                j |> List.nth Childs <! sprintf "%d %d" cur k 
                | _ ->  failwith "unknown message"
                
                //Calculations for CPU Time, Real Time and Cores Used
                let rTime = timer.ElapsedMilliseconds
                printfn "Real Time: %d ms" rTime
                let cTime = int64 (pId.TotalProcessorTime-cpu_time_stamp).TotalMilliseconds
                printfn "CPU Time: %d ms" cTime
                if cTime > rTime then 
                    printfn"Cores Used: %f" ((float cTime)/(float rTime))
                printfn"Program Ended. Press Enter."

        //Spawning the Boss Actoe    
        let Boss = system.ActorOf(Props(typedefof<boss>, Array.empty))

        //Passing the message to the Boss with the inputs received
        Boss <! sprintf "%d %d" final k

        
        System.Console.ReadLine() |> ignore
        
        
        

        

        