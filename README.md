# Polyglot Notebook Logger

A teeny-tiny logging library for Notebook

## Usage

```cs
#r "nuget: Polygot.Notebook.Logger"
```

```cs
using Polygot.Notebook.Logger;
```

```cs
Log.Debug("Hi there, I am Polyglot.Notebook.Logger");
Log.Info("Hi there, I am Polyglot.Notebook.Logger");
Log.Warn("Hi there, I am Polyglot.Notebook.Logger");
Log.Error("Hi there, I am Polyglot.Notebook.Logger");
Log.Critical("Hi there, I am Polyglot.Notebook.Logger");
```

## Output

A **COLORED** logging will be display in the output cell. The TEXT of which looks like:

```bat
01 03:25:01.09 | Debug | Hi there, I am Polyglot.Notebook.Logger
01 03:25:01.10 | Debug | Hi there, I am Polyglot.Notebook.Logger
01 03:25:01.10 | Warn  | Hi there, I am Polyglot.Notebook.Logger
01 03:25:01.10 | Err   | Hi there, I am Polyglot.Notebook.Logger
01 03:25:01.10 | Crit  | Hi there, I am Polyglot.Notebook.Logger
```

## Progress Report

A simple progress bar can also be logged. One can modify the colors if desired

```cs
var pi = new ProgressIndicator(maxCount: 10, label: "Example Progress Status");
pi.Increment(); // Increment the Progress
pi.Increment(2); // Increment by given int

10.0% [■■■...........................] | 1/10 | 0.104 @ 0.104/it ETA: 00:00:00 | Example Progress Status

30.0% [■■■■■■■■■.....................] | 3/10 | 0.203 @ 0.099/it ETA: 00:00:00 | Example Progress Status
```


## Example (Notebook)

See [Example.ipynb](Example.ipynb) to get started!
