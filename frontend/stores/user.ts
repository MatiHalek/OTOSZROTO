export const useUserStore = defineStore('userStore', {
    state: () => ({
      isLogged: false,
    }),
    actions: {
      async logIn() {
        this.isLogged = true;
      }
    }
  })