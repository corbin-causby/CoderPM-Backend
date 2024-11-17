using Microsoft.EntityFrameworkCore;

await using var db = new SignInDetailContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Read
Console.WriteLine("Querying for sign in details");

var results = 
    from signindetail in db.SignInDetails
    where signindetail.SignInDetailId == 1
    select signindetail;

if (results.Any())
{
    await foreach (var s in results.AsAsyncEnumerable())
    {
        Console.WriteLine("Sign In Id: " + s.SignInDetailId + "    Sign In Email: " + s.UserEmail);
    }
}
else
{
    Console.WriteLine("No results found.");
}

