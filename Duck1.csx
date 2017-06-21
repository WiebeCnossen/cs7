using System;

class Duck {
  public override string ToString() => nameof(Duck);
}

bool WalksLikeDuckAndQuacksLikeDuck(Duck duck) => duck != null;

void Doit(object obj) {
  // We call it a duck first
  var duck = obj as Duck;

  // Now we check if we were right
  if (WalksLikeDuckAndQuacksLikeDuck(duck)) {
    // we can use it as a duck
    Console.WriteLine($"It's a duck: {duck}");
  }

  // maybe not a duck, but nobody is stopping us
  Console.WriteLine($"It's maybe not a duck: {duck}");
}

Doit(new Duck());
Doit(nameof(Duck));