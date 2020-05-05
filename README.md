# WritingGit
An app for writers using git.

## Inspiration

I write.  Recently I've been using git as a version control for some of my writing.  This app is partly inspirated by the site [penflip.com](https://www.penflip.com). But the site seems to be abandoned for the most part.

My current tools on the desktop is Visual studio code with the following extensions:

* Markdown Preview Enhanced
* Markdownlint
* Spell Right

It works, I can write markdown and have git integration.  But VSCode is not a word processor.  It's made possible through extensions but I want more.

My other consideration is mobile.  Currently I do all of my writing though google docs on mobile.  But for the few git projects I have I use two android apps:

* Pocket Git
* Markor

These work quite nicely, but I'd like a single app solution.  

## Challenges

I'm a dotnet dev, I do have some small knowledge in java, but I'd like to do this in a dotnet stack.  So my main challenge is trying to find a git integration that works desktop and mobile.

I am currently looking at libgit2sharp and seeing if i can get an android build.  Or more recently I've found a WASM implemtation.  So maybe a Blazor WASM PWS is the right path.
