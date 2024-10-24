<template>
    <AppForm>
        <PageTitle>Zaloguj się</PageTitle>

        <VerticalGroup class="gap-y-6 relative">
            <VerticalGroup>
                <InputLabel for="loginInputEmail">Adres e-mail:</InputLabel>
                <AppInput type="email" id="loginInputEmail" />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel for="loginInputPassword">Hasło:</InputLabel>
                <AppInput type="password" id="loginInputPassword" />
            </VerticalGroup>

            <ConfirmButton>Zaloguj się</ConfirmButton>
            <p>
                <span>Nie masz konta? </span>
                <NuxtLink :to="'/rejestracja'" class="text-[#463691]">Zarejestruj się</NuxtLink>
            </p>
        </VerticalGroup>
    </AppForm>
</template>

<script setup>
    definePageMeta({
        layout: 'clear'
    })
</script>

<style scoped>

</style>