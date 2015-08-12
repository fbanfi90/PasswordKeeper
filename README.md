# PasswordKeeper
A simple desktop application which allows to keep passwords organized and protected.
PasswordKeeper is written in C#, and targets the .NET Framework 2.0 (could be probably ported easily to Mono).

WARNING: since it was an old project of mine, and I still wasn't that acquainted with crypto, the current implementation doesn't provide CPA-security (the IV is set to 0), but the code will be soon fixed.
