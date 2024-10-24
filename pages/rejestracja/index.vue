<template>
    <AppForm>
        <PageTitle>Utwórz konto</PageTitle>

        <VerticalGroup class="gap-y-6">
            <VerticalGroup>
                <InputLabel>Adres e-mail:</InputLabel>
                <AppInput />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel>Numer telefonu:</InputLabel>
                <AppInput />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel>Hasło:</InputLabel>
                <AppInput />
            </VerticalGroup>

            <VerticalGroup>
                <VerticalGroup>
                    <InputLabel>Powtórz hasło:</InputLabel>
                    <AppInput />
                </VerticalGroup>

                <AppCheckBox>
                    Zapoznałem się z regulaminem portalu
                </AppCheckBox>
            </VerticalGroup>

            <ConfirmButton>Utwórz konto</ConfirmButton>
            <p>
                <span>Masz już konto? </span>
                <NuxtLink :to="'/logowanie'" class="text-[#463691]">zaloguj się</NuxtLink>
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