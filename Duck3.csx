using System;

class Duck {
  public override string ToString() => nameof(Duck);
}

bool WalksLikeDuckAndQuacksLikeDuck(Duck duck) => duck != null;

void Doit(object obj) {
  if (!(obj is Duck duck)) {
    throw new ArgumentException("Not a duck", nameof(duck));
  }

  // this is really a duck
  Console.WriteLine($"It's a duck: {duck}");
}

Doit(new Duck());
Doit(nameof(Duck));