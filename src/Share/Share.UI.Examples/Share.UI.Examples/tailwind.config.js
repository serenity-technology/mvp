module.exports = {
    darkMode: 'selector',
    content: {
        files: [
            '../../Share.UI/**/*.razor',
            '../../Share.UI/**/*.razor.cs',

            './**/*.razor',
            './**/*.razor.cs',

            '../Share.UI.Examples.Client/**/*.razor',
            '../Share.UI.Examples.Client/**/*.razor.cs'
        ]
    },
    theme: {
        screens: {
            md: '640px',
            lg: '1008px'
        }
    },
    plugins: [
        require('@tailwindcss/typography'),
        require('@tailwindcss/forms'),
        require('@tailwindcss/aspect-ratio'),
        require('@tailwindcss/container-queries')
    ]
}