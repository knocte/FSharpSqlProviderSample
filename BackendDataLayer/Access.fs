namespace BackendDataLayer

open FSharp.Data.Sql

module Access =

    [<Literal>]
    let private connStr =
        "Server=localhost;Port=5432;Database=runintomedb;User Id=postgres;Password='localDevPassword'"

    [<Literal>]
    let private resolutionPath = @"lib"

    type SQL =
        SqlDataProvider<Common.DatabaseProviderTypes.POSTGRESQL, connStr, Owner="public, admin, references", UseOptionTypes=true, ResolutionPath=resolutionPath>

    let test() : unit =
        let ctx = SQL.GetDataContext()

        let firstRelRow =
            query {
                for e in ctx.Public.Relationships do
                    select(e.UserId, e.AssigneeId)
            }
            |> Seq.tryHead

        match firstRelRow with
        | None -> printfn "No relationships in DB so far"
        | Some(userId, assigneeId) ->
            printfn "First relationship is %i with %i!" userId assigneeId
