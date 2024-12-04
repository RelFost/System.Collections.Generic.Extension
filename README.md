
# System.Collections.Generic.Extension

This library provides a set of extension methods for `Dictionary<TKey, TValue>` in .NET Framework 4.8.1. These extensions are designed to simplify and enhance common operations such as adding, updating, and retrieving dictionary entries.

## Features

- **ContainsAllKeys / ContainsKeys**  
  Checks if all keys from a given collection exist in the dictionary.

- **ContainsAnyKey**  
  Checks if at least one key from a given collection exists in the dictionary.

- **GetOrAdd**  
  Retrieves the value for a key or adds a new value using either a factory function, a default value, or an explicitly provided value.

- **GetOr**  
  Retrieves the value for a key if it exists. If not, it calls the provided callback to generate a value.

- **UpdateOrAdd**  
  Updates an existing entry or adds a new one. Supports direct updates, actions, or custom value factories.

## Installation

1. Place the `Relfost.System.Collections.Generic.Extension.dll` file into your project directory.
2. Add a reference to the DLL in your project.
3. Import the namespace in your code:
   ```csharp
   using System.Collections.Generic;
   ```

## Usage

### ContainsAllKeys / ContainsKeys

```csharp
var dictionary = new Dictionary<string, int>
{
    { "key1", 1 },
    { "key2", 2 }
};

var keys = new List<string> { "key1", "key2" };

bool allKeysExist = dictionary.ContainsAllKeys(keys); // True
bool allKeysExistAlternative = dictionary.ContainsKeys(keys); // True
```

### ContainsAnyKey

```csharp
var keysToCheck = new List<string> { "key2", "key3" };
bool anyKeyExists = dictionary.ContainsAnyKey(keysToCheck); // True
```

### GetOrAdd

```csharp
var dictionary = new Dictionary<string, int>();

// Using a factory function
int value = dictionary.GetOrAdd("key1", () => 42); // Adds and returns 42

// Using the default value
int defaultValue = dictionary.GetOrAdd("key2"); // Adds and returns 0

// Using an explicitly provided default value
int customDefault = dictionary.GetOrAdd("key3", 10); // Adds and returns 10
```

### GetOr

```csharp
var dictionary = new Dictionary<string, string>();

// Retrieve or compute a value using a callback
string value = dictionary.GetOr("key1", key => $"GeneratedValueFor_{key}"); // Adds and returns "GeneratedValueFor_key1"
```

### UpdateOrAdd

```csharp
var dictionary = new Dictionary<string, int>();

// Direct update or add
dictionary.UpdateOrAdd("key1", 20); // Adds "key1" with value 20

// Update with an action
dictionary.UpdateOrAdd("key1", value => value += 10); // Updates "key1" to 30

// Update or add with a factory
dictionary.UpdateOrAdd("key2", value => value += 5, () => 50); // Adds "key2" with value 50
```

## Requirements

- .NET Framework 4.8.1

## Contributing

Feel free to fork this repository and submit pull requests. All contributions are welcome!

## License

This project is licensed under the MIT License.
