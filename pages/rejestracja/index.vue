<template>
    <AppForm>
        <PageTitle>Utwórz konto</PageTitle>

        <VerticalGroup class="gap-y-6 relative">
            <VerticalGroup>
                <InputLabel for="registrationInputEmail">Adres e-mail:</InputLabel>
                <AppInput type="email" id="registrationInputEmail" />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel for="registrationInputPhone">Numer telefonu:</InputLabel>
                <AppInput type="tel" id="registrationInputPhone" />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel for="registrationInputPassword">Hasło:</InputLabel>
                <AppInput type="password" id="registrationInputPassword" />
            </VerticalGroup>

            <VerticalGroup>
                <VerticalGroup>
                    <InputLabel for="registrationInputPassword2">Powtórz hasło:</InputLabel>
                    <AppInput type="password" id="registrationInputPassword2" />
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