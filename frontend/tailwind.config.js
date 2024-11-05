/** @type {import('tailwindcss').Config} */
export default {
  content: [],
  theme: {
    extend: {
      backgroundImage: {
        'registration-background': "url('/img/background.jpg')",
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
  important: true
}

