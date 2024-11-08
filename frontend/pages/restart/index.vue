<template>
    <div class="container mx-auto">
        <h2 class="text-2xl text-center py-4">Zmień hasło</h2>

        <AppInput v-model="password" :type="'password'"/>

        <ConfirmButton @click="changePassword()">Zmień hasło</ConfirmButton>
    </div>
</template>

<script setup>
    const password = ref();

    const route = useRoute();
    const token = route.query.token;

    async function changePassword() {
        const response = await $fetch(`http://localhost:5271/api/auth/reset/${token}-${password.value}`, {
            method: 'put'
        });

        if(response == 'success') {
            await navigateTo('/logowanie');
        }

        //console.log(response);
    }
</script>