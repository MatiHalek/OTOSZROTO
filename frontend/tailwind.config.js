/** @type {import('tailwindcss').Config} */

export default {
  darkMode: 'selector',
  content: [],
  theme: {
    extend: {
      backgroundImage: {
        'registration-background': "url('/img/background.jpg')",
        'main-background': "linear-gradient(rgba(255, 255, 255, 0.85), rgba(255, 255, 255, 0.85)), url('/img/background.jpg')",
        'main-dark-background': "linear-gradient(rgba(15, 23, 42, 0.85), rgba(15, 23, 42, 0.85)), url('/img/background.jpg')",
      },
      dropShadow: {
        'lg': ['0 10px 8px rgb(0 0 0 / 0.08)',
          '0 4px 3px rgb(0 0 0 / 0.2)'
        ],
      },
      boxShadow: {
        'special': '0 0 10px 1px #46369188',
      }
    },
  },
  plugins: [],
}

