<template>
    <AppForm>
        <PageTitle>Zaloguj się</PageTitle>

        <VerticalGroup class="gap-y-6">
            <VerticalGroup>
                <InputLabel>Adres e-mail:</InputLabel>
                <AppInput />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel>Hasło:</InputLabel>
                <AppInput />
            </VerticalGroup>

            <ConfirmButton>Zaloguj się</ConfirmButton>
            <p>
                <span>Nie masz konta? </span>
                <NuxtLink :to="'/rejestracja'" class="text-[#463691]">zarejestruj się</NuxtLink>
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