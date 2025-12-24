# Data Structures And Algorithm Course

Purpose
-------
This repository is a day-to-day, step-by-step learning log and code collection for studying data structures and algorithms using C#. The goal is to learn concepts, implement them in C#, test them, and document progress. Primary learning resource used throughout is W3Schools (C# reference and tutorials): https://www.w3schools.com/cs/

Quick summary
-------------
- Language: C#
- IDE: Visual Studio 2022 (instructions included)
- Study style: small focused lessons, implement, test, document, reflect
- Primary web resource: W3Schools C# (https://www.w3schools.com/cs/)

Repository layout (suggested)
-----------------------------
Use the following or adapt to your existing layout:

- `README.md` — this file (daily workflow + templates)
- `src/` — implementations (one folder per day/topic)
  - `src/Day01_Basics/`
  - `src/Day02_Arrays/`
  - `src/Day03_LinkedList/`
  - ...
- `tests/` — unit tests for implementations
- `docs/` — notes, diagrams, references
- `examples/` — small runnable example projects
- `.github/` — CI, issue templates (optional)

Daily learning workflow (repeatable)
-----------------------------------
1. Pick a focused topic (e.g., `Arrays`, `Singly Linked List`, `Binary Search`).
2. Read the concept on W3Schools and one complementary source if needed.
   - W3Schools C# tutorial: https://www.w3schools.com/cs/
3. Sketch the design and algorithm in `docs/` (pseudocode, complexity).
4. Implement minimal, readable C# code under `src/DayXX_Topic/`.
5. Add unit tests under `tests/` that validate edge cases and normal cases.
6. Run and debug in Visual Studio:
   - Open the solution or folder via __File > Open > Project/Solution__ or __File > Open > Folder__.
   - Build via __Build > Build Solution__.
   - Run/debug via __Debug > Start Debugging__.
7. Commit with a concise message and push, then write a short daily note (template below).
8. Reflect on complexity, pitfalls, and possible optimizations.

Daily log template (use in `docs/daily-log.md` or each day's folder)
-------------------------------------------------------------------
- Date: YYYY-MM-DD
- Topic: (e.g., "Singly Linked List — Insert/Remove")
- Goals: (short, measurable)
- Resources:
  - W3Schools C#: https://www.w3schools.com/cs/
  - Other: (optional link)
- Notes: (key points learned)
- Pseudocode / Approach:
  - ...
- Files changed:
  - `src/Day03_LinkedList/LinkedList.cs`
  - `tests/Day03_LinkedListTests.cs`
- Test results: (pass/fail summary)
- Time spent: (e.g., 1.5 hours)
- Next steps / TODOs

Example daily note
------------------
- Date: 2025-12-24
- Topic: Arrays — Two-sum brute force and hash approach
- Goals: Implement two approaches and compare complexity
- Resources: W3Schools C# (arrays & dictionaries)
- Notes: Brute force O(n^2). Hash map approach O(n) average.
- Files changed:
  - `src/Day02_Arrays/TwoSumBrute.cs`
  - `src/Day02_Arrays/TwoSumHash.cs`
- Test results: All tests passed (5/5)
- Time spent: 2 hours
- Next steps: Add more edge case tests (duplicates, negative numbers)

Recommended commit and branch rules
----------------------------------
- Branch naming: `feature/day-XX-topic` or `chore/docs-day-XX`
- Commit messages: `Day 03: Implement SinglyLinkedList Insert/Remove + tests`
- Small commits that map to one learning objective
- Use PRs for major reorganizations or when collaborating

Running examples & tests
-----------------------
1. Open repository in Visual Studio 2022:
   - __File > Open > Project/Solution__ (if `.sln` exists) or __File > Open > Folder__.
2. Restore NuGet packages (if used) via __Build > Restore NuGet Packages__.
3. Build solution: __Build > Build Solution__.
4. Run unit tests: open Test Explorer (__Test > Test Explorer__), then __Run All__ or run the specific test.
5. Use breakpoints and __Debug > Start Debugging__ for step-through.

Style and best practices
------------------------
- Keep methods small and focused.
- Write unit tests for normal and boundary cases.
- Prefer clear variable names over clever ones.
- Add XML documentation for public classes/methods when appropriate.
- Note algorithm time/space complexity in comments or `docs/`.

Resources
---------
- W3Schools C# Tutorials — https://www.w3schools.com/cs/
- W3Schools C# Array reference — https://www.w3schools.com/cs/cs_arrays.php
- (Optional) GeeksforGeeks and CLRS for algorithm theory

Contributing
------------
- Add or update daily notes and code under a new `DayXX_*` folder.
- Keep PRs small and focused.
- Document every new data structure or algorithm with at least:
  - short explanation,
  - complexity analysis,
  - one or more unit tests.

License
-------
- Consider `MIT` for a personal learning repo. Add `LICENSE` if you want to publish.

What I added/changed
--------------------
- Created a purpose-built `README.md` that defines a reproducible day-to-day learning process, repo layout, templates for daily logs, example entries, and Visual Studio 2022 run/test instructions (commands are shown with underscores as requested).
- Emphasized W3Schools as the primary resource per your request and included direct links.

Next steps you can take
-----------------------
- Copy this `README.md` into the repository root.
- Add one sample day folder (e.g., `src/Day01_Basics/`) with code and a `docs/daily-log.md` using the provided template.
- If you want, I can generate a sample `Day01` implementation and unit tests to get you started.


