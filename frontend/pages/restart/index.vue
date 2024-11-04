<template>
    <div>
        <AppInput v-model="password" :type="'password'"/>

        <button @click="changePassword()">Zmień hasło</button>
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

        console.log(response);
    }
</script>