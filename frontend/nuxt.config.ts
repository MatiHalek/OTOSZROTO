// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2024-04-03',
  devtools: { enabled: true },
  modules: [
    '@nuxtjs/tailwindcss',
    '@nuxt/test-utils/module'
  ],

  components: [
    {
      path: '~/components',
      pathPrefix: false,
    }
  ],
  css: ['~/assets/css/main.css',
      '@fortawesome/fontawesome-free/css/all.css',
  ],
  ssr: true
})