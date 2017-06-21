using System;

class Duck {
  public override string ToString() => nameof(Duck);
}

bool WalksLikeDuckAndQuacksLikeDuck(Duck duck) => duck != null;

void Doit(object obj) {
  if (obj is Duck duck) {
    // this is really a duck
    Console.WriteLine($"It's a duck: {duck}");
  }
 
  // maybe not a duck, but nobody is stopping us, or?
  Console.WriteLine($"It's maybe not a duck: {duck}");
}

Doit(new Duck());
Doit(nameof(Duck));