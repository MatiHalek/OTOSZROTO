<template>
    <div class="container mx-auto">
        <h2 class="text-3xl text-center py-4 font-bold my-4">Zmień hasło</h2>
        <AppInput v-model="password" :type="'password'" style="color: black;"/>
        <p v-if="errorMessage" class="text-red-500 text-center mt-2 font-semibold">{{ errorMessage }}</p>
        <div class="text-center">
          <ConfirmButton @click="changePassword()" class="font-semibold"><i class="fa-solid fa-circle-check me-2"></i>Zmień hasło</ConfirmButton>  
        </div>
    </div>
</template>

<script setup>
    useHead({
            title: 'Zmień hasło | OTOSZROTO'
    });
    const password = ref('');
    const errorMessage = ref('');
    const route = useRoute();
    const token = route.query.token;

    async function changePassword() {
        if (password.value.length < 8 || password.value.length > 50) {
            errorMessage.value = 'Hasło musi mieć od 8 do 50 znaków!';
            return;
        }
        errorMessage.value = '';
        
        const response = await $fetch(`http://localhost:5271/api/auth/reset/${token}-${password.value}`, {
            method: 'put'
        });

        if(response == 'success') {
            await navigateTo('/logowanie');
        }
    }
</script>
