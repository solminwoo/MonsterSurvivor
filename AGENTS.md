# MonsterSurvivor engineering guidance

<!-- ecc-engineering-defaults:start -->
## Engineering defaults
For coding work, read [.engineering/defaults.md](.engineering/defaults.md).
These are shared fallback conventions; the existing project owner, nested instructions,
skills, model choices, domain contracts and stronger verification/release gates remain authoritative.
No hooks, permissions, MCP services or background automation are installed by this guidance.

### Project adaptation
Unity project: read `ProjectSettings/ProjectVersion.txt` and package manifests; preserve `.meta` GUIDs and scene/prefab references. Validate affected gameplay with the matching Editor, including EditMode/PlayMode tests when available. Do not commit regenerated Library, Logs, UserSettings or build artifacts.
<!-- ecc-engineering-defaults:end -->
