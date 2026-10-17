# DataQuest Hybrid

Cross-platform detective puzzle game built with Unity and C# for Android and WebGL.

## Project status

The repository now contains a Unity foundation and a first web MVP. The web MVP uses the evidence-based question format from `DataQuest_150_Evidence_Wise_MCQ.docx` and currently seeds the first five questions for the gameplay loop.

## Run the web MVP

Open `web/index.html` in a browser, or serve the repository with any static server. Create a local investigator account, answer questions for 20 points, and spend 50 points to reveal a hint. Login and score are persisted in browser local storage for this prototype.

## Planned gameplay

- Detective cases with interactive data puzzles and deductions
- XP, levels, and sequential case unlocking
- Local progress saves and replay
- Platform-specific advertising integration, initially disabled

## Technology and targets

- Unity 6 and C# for shared gameplay
- WebGL for browser play
- Android for mobile releases

## Getting started

Clone this repository. It currently contains project documentation, a Unity `.gitignore`, and an MIT license. Unity project files, scenes, dependencies, and build instructions will be added with the initial implementation.

## Initial development milestones

1. Import or create the Unity project and record the exact editor version.
2. Implement the detective cases, puzzle interactions, progression, and saves.
3. Validate gameplay in the Unity Editor.
4. Build and test WebGL and Android releases.

## License

This repository is licensed under the [MIT License](LICENSE). Third-party assets and dependencies retain their respective licenses.
