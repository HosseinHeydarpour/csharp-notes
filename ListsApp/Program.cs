using System.Collections;

namespace ListsApp
{
    internal class Program
    {

        // Usage in Real Scenarios
        //
        // Nullable types are especially useful when a variable may not apply,
        // or when a value might be missing / unknown.
        //
        // Example 1: Database Interaction
        // - A database field may return null if it has not been set.
        // - Nullable types help you represent that "no value" case safely.
        //
        // Example:
        //
        // string? middleName = user.MiddleName; // may be null
        // if (middleName != null)
        // {
        //     Console.WriteLine($"Middle name: {middleName}");
        // }
        // else
        // {
        //     Console.WriteLine("Middle name not provided");
        // }
        //
        // Example 2: Form Data
        // - In forms, users may leave optional fields blank.
        // - Nullable types can show whether a response was provided.
        //
        // Example:
        //
        // int? age = form.OptionalAge; // nullable int
        // if (age.HasValue)
        // {
        //     Console.WriteLine($"Age: {age.Value}");
        // }
        // else
        // {
        //     Console.WriteLine("Age not entered");
        // }
        //
        // Example 3: Search / API Results
        // - Sometimes an API or search query returns no matching result.
        // - Instead of using a default value, null indicates "not found".
        //
        // Example:
        //
        // Product? product = productService.FindById(id); // may return null
        // if (product == null)
        // {
        //     Console.WriteLine("Product not found");
        // }
        //
        // Example 4: Optional Config Settings
        // - Some configuration settings may be missing.
        // - Nullable types let you check whether the setting exists before using it.
        //
        // Example:
        //
        // string? theme = config.Theme; // may be null
        // string appliedTheme = theme ?? "light"; // null‑coalescing operator
        // Console.WriteLine($"Applied theme: {appliedTheme}");
        //
        // Example 5: User Profile Data
        // - Not all users fill in every profile field.
        // - Nullable fields clearly indicate missing information.
        //
        // Example:
        //
        // string? phoneNumber = profile.PhoneNumber; // nullable string
        // if (!string.IsNullOrEmpty(phoneNumber))
        // {
        //     Console.WriteLine($"Phone: {phoneNumber}");
        // }



        // Benefits of Using Nullable Types
        //
        // 1. Safety
        // - Prevents runtime errors when accessing values that may be missing.
        // - Encourages safer, more defensive coding.
        //
        // Example (Unsafe):
        // string name = user.Name; // may be null
        // Console.WriteLine(name.Length); // ❌ NullReferenceException
        //
        // Example (Safe with Nullable and Null-Conditional Operator):
        // string? name = user.Name; // nullable string
        // Console.WriteLine(name?.Length); // ✅ Safe, prints null instead of throwing
        //
        // Example (Using Null-Coalescing Operator):
        // Console.WriteLine(name ?? "No name provided");
        //
        //
        // 2. Clarity
        // - Nullable syntax (`?`) makes it obvious when a variable might be missing.
        // - Helps future developers understand which fields are optional.
        //
        // Example (Unclear):
        // string middleName; // Is this nullable? Required? Unknown.
        //
        // Example (Clear Nullable Definition):
        // string? middleName; // clearly optional
        //
        // Example (Using Nullable Value Types):
        // int? age = null; // age may be missing
        //
        // if (age.HasValue)
        //     Console.WriteLine($"Age: {age.Value}");
        // else
        //     Console.WriteLine("Age not provided");
        //
        //
        // 3. Maintainability
        // - Improves readability and reduces debugging complexity.
        // - Encourages consistent null handling across the codebase.
        //
        // Example:
        // public class User
        // {
        //     public string Username { get; set; } = "";  // required
        //     public string? PhoneNumber { get; set; }    // optional
        //     public int? Rating { get; set; }            // optional numeric
        // }
        //
        // // It's instantly clear which properties may be missing (null).



        static void Main(string[] args)

        {
            // This will give us compiler error -  int is not a nullable value type
            //int age = null;

            // Now this becomes a nullable int - int?
            int? age = null;
            int myAge = 28;

            // Has value returns wether the nullable has a value
            if(age.HasValue)
            {
                // we can do this operation here || we are sure here it has a value
                int sum = age.Value + myAge;

                // When we are working with with nullable values we can use this .Value property also HasValue
                Console.WriteLine("Age is: "+ age.Value);
            } else
            {
                // 1. we cannot say age + myAge -> We have to access .Value
                // 2. age? must have a value here otherwise we will get an error - excception
                // in other words we can only add a non nullable to a nullable only if we can access to the nullable value
                //int sum = age.Value + myAge;

                // because age here is null it will ignore it
                Console.WriteLine("Age is not specified... :("+age );
            }

                Console.ReadLine();
        }



    }
}