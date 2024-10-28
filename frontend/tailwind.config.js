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
      }
    },
  },
  plugins: [],
}

