module.exports = {
    "dataSource": "issues",
    "prefix": "",
    "onlyMilestones": false,
    "ignoreIssuesWith": [
		"duplicate",
		"invalid",
		"question",
		"wontfix"
	],
    "groupBy": {
        "⚒ Enhancements": ["⚒ Enhancement"],
		"🔧 Native Changes (C++)": [ "🔧 Native" ],
        "⚙ Build & DevOps": ["⚙ DevOps" ],
        "🐛 Bugs Fixed:": ["🐛 Bug"],
        "🧪 Testing and Samples": ["🧪 Testing"],
        "📓 Documentation Improvements:": ["📓 Documentation" ]
    },
    "changelogFilename": "CHANGELOG.md",
    "template": {
        commit: ({ message, url, author, name }) => `- [${message}](${url}) - ${author ? `@${author}` : name}`,
        issue: "- [{{text}}]({{url}}) {{name}}",
        label: "[**{{label}}**]",
        noLabel: "closed",
        group: "\n#### {{heading}}\n",
        changelogTitle: "# Changelog\n\n",
        release: "## {{release}} ({{date}})\n{{body}}",
        releaseSeparator: "\n---\n\n"
    }
}