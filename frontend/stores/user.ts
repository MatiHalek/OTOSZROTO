export const useUserStore = defineStore('userStore', {
    state: () => ({
      isLogged: false,
      email: ''
    }),
    actions: {
      async logIn(data: any) {
        this.isLogged = true;

        if(data) {
          this.email = data.email;
        }
      }
    }
  })