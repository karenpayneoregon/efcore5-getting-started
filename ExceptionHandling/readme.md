# About

Provides an easy way to log exceptions if not into a third party library to a file.

```csharp
catch (Exception e)
{
    Exceptions.Write(e);
}
```