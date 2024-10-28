<template>
    <ResetPasswordModal :isVisible="isModalVisible" @close="isModalVisible = false" />

    <AppForm>
        <PageTitle>Logowanie</PageTitle>
        <VerticalGroup class="gap-y-6 relative overflow-auto grow">         
            <VerticalGroup>
                <InputLabel for="loginInputEmail">Adres e-mail</InputLabel>
                <AppInput class="shadow-xl" type="email" id="loginInputEmail" />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel for="loginInputPassword">Hasło</InputLabel>
                <AppInput class="shadow-xl" type="password" id="loginInputPassword" />
            </VerticalGroup>
            <p @click="isModalVisible = true" class="text-right text-[#463691] font-medium cursor-pointer">Nie pamiętam hasła</p>

            <ConfirmButton class="shadow-xl">Zaloguj się</ConfirmButton>
            <p class="text-center">
                <span>Nie masz konta? </span>
                <NuxtLink :to="'/rejestracja'" class="text-[#463691]">Zarejestruj się</NuxtLink>
            </p>
        </VerticalGroup>
        <p class="relative border-t-4 text-center py-2 mt-3 rounded">&copy;2024 Grupa OTOSZROTO</p>
    </AppForm>
</template>

<script setup>
    definePageMeta({
        layout: 'clear'
    });

    useHead({
        title: 'Logowanie | OTOSZROTO'
    });

    const isModalVisible = ref(false);
</script>

<style scoped>

</style>