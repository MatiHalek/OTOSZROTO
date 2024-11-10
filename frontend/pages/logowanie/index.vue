<template>
    <ResetPasswordModal :isVisible="isModalVisible" @close="isModalVisible = false" />

    <AppForm>
        <NuxtLink to="/" title="Strona główna OTOSZROTO" class="relative mx-auto mt-4">
            <div class="flex items-center gap-1 border-y-4 border-y-transparent hover:border-b-[#E5A00A] transition-all">           
                <img src="/img/logo.png" alt="Logo strony" width="50" height="50">
                <h1 class="text-2xl font-extrabold text-[#E5A00A]">
                    <span class="text-[#463691]">OTO</span>SZROTO
                </h1>                   
            </div>
        </NuxtLink>

        <VerticalGroup>
            <PageTitle>Logowanie</PageTitle>
        </VerticalGroup>
        <p class="text-red-600 z-20 text-center -mt-5 pb-10 font-medium">{{ errorMessage }}</p>

        <VerticalGroup class="gap-y-6 relative overflow-auto grow">         
            <VerticalGroup>
                <InputLabel for="loginInputEmail">Adres e-mail</InputLabel>
                <AppInput v-model="userData.Email" :validate="false" class="shadow-xl" type="email" id="loginInputEmail" />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel for="loginInputPassword">Hasło</InputLabel>
                <AppInput v-model="userData.Password" :validate="false" class="shadow-xl" type="password" id="loginInputPassword" />
            </VerticalGroup>
            <p @click="isModalVisible = true" class="text-right text-[#463691] font-medium cursor-pointer">Nie pamiętam hasła</p>

            <ConfirmButton class="shadow-xl" @click.prevent="loginUser()">Zaloguj się</ConfirmButton>
            <p class="text-center">
                <span>Nie masz konta? </span>
                <NuxtLink :to="'/rejestracja'" class="text-[#463691]">Zarejestruj się</NuxtLink>
            </p>
        </VerticalGroup>
        <p class="relative border-t-4 text-center py-2 mt-3 rounded">&copy; 2024 Grupa OTOSZROTO</p>
    </AppForm>
</template>

<script setup>
    definePageMeta({
        layout: 'clear',
    });

    useHead({
        title: 'Logowanie | OTOSZROTO'
    });

    const user = useUserStore();

    onMounted(async () => {
        if(user.isLogged) {
            await navigateTo('/profil');
        }
    })

    const isModalVisible = ref(false);

    const userData = ref({
        Email: '',
        Password: ''
    });

    const errorMessage = ref('');

    async function loginUser() {
        try {
            const response = await $fetch('http://localhost:5271/api/auth/login', {
                method: 'POST',
                body: {
                    "email": userData.value.Email,
                    "password": userData.value.Password
                },
                credentials: 'include'
            });

            if (response.message === 'success') {
                const user = useUserStore()

                const response = await $fetch('http://localhost:5271/api/auth/user', { method: 'get', credentials: 'include', responseType: 'json' });

                if(response) {
                    user.logIn(response);

                    await navigateTo('/');
                }
            }
        } catch (error) {
            if(error.data.message == "Invalid Credentials") {
                errorMessage.value = "Nieprawidłowy e-mail lub hasło!";
            }
        }
    }
</script>

<style scoped>

</style>