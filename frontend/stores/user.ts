export const useUserStore = defineStore('userStore', {
    state: () => ({
      isLogged: false,
      userId: '',
      email: '',
      name: '',
      surname: '',
      phone: ''
    }),
    actions: {
      async logIn(data: any) {
        this.isLogged = true;

        if(data) {
          this.userId = data.userID;
          this.email = data.email;
          this.name = data.name;
          this.surname = data.surname;
          this.phone = data.phoneNumber;
        }
      }
    }
  })