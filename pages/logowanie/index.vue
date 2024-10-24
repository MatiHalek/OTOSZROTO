<template>
    <AppForm>
        <PageTitle>Zaloguj się</PageTitle>

        <VerticalGroup class="gap-y-6 relative">
            <VerticalGroup>
                <InputLabel>Adres e-mail:</InputLabel>
                <AppInput type="email" />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel>Hasło:</InputLabel>
                <AppInput type="password" />
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