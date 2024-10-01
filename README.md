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

```
01 03:25:01.09 | Debug | Hi there, I am Polyglot.Notebook.Logger
01 03:25:01.10 | Debug | Hi there, I am Polyglot.Notebook.Logger
01 03:25:01.10 | Warn  | Hi there, I am Polyglot.Notebook.Logger
01 03:25:01.10 | Err   | Hi there, I am Polyglot.Notebook.Logger
01 03:25:01.10 | Crit  | Hi there, I am Polyglot.Notebook.Logger
```