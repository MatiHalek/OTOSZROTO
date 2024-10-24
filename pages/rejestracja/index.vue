<template>
    <AppForm>
        <PageTitle>Utwórz konto</PageTitle>

        <VerticalGroup class="gap-y-6 relative">
            <VerticalGroup>
                <InputLabel>Adres e-mail:</InputLabel>
                <AppInput type="email" />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel>Numer telefonu:</InputLabel>
                <AppInput type="tel" />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel>Hasło:</InputLabel>
                <AppInput type="password" />
            </VerticalGroup>

            <VerticalGroup>
                <VerticalGroup>
                    <InputLabel>Powtórz hasło:</InputLabel>
                    <AppInput type="password" />
                </VerticalGroup>

                <AppCheckBox>
                    <span class="cursor-pointer select-none">Oświadczam, że znam i akceptuję postanowienia serwisu OTOSZROTO.</span>
                </AppCheckBox>
            </VerticalGroup>

            <ConfirmButton>Utwórz konto</ConfirmButton>
            <p>
                <span>Masz już konto? </span>
                <NuxtLink :to="'/logowanie'" class="text-[#463691]">Zaloguj się</NuxtLink>
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