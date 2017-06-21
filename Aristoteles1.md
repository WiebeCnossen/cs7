Implementation hiding
=====================

```
var socrates = myDependencyContainer.Resolve<ISocrates>();
socrates.IsMortal;
```

"Its interface or definition was chosen to reveal as little as possible about its inner workings." — [Parnas, 1972b]