<template>
    <AppForm>
        <PageTitle>Załóż konto</PageTitle>
        <VerticalGroup class="gap-y-6 relative overflow-auto grow">     
            <VerticalGroup>
                <InputLabel for="registrationInputEmail">Adres e-mail<span class="text-red-600 text-xl">*</span></InputLabel>
                <AppInput type="email" id="registrationInputEmail" class="shadow-xl" />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel for="registrationInputPhone">Numer telefonu<span class="text-red-600 text-xl">*</span></InputLabel>
                <AppInput type="tel" id="registrationInputPhone" class="shadow-xl" />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel for="registrationInputPassword">Hasło<span class="text-red-600 text-xl">*</span></InputLabel>
                <AppInput type="password" id="registrationInputPassword" class="shadow-xl" />
            </VerticalGroup>

            <VerticalGroup>
                <VerticalGroup>
                    <InputLabel for="registrationInputPassword2">Powtórz hasło<span class="text-red-600 text-xl">*</span></InputLabel>
                    <AppInput type="password" id="registrationInputPassword2" class="shadow-xl" />
                </VerticalGroup>

                <AppCheckBox>
                    <span class="cursor-pointer select-none">Oświadczam, że znam i akceptuję postanowienia serwisu OTOSZROTO.<span class="text-red-600 text-xl">*</span></span>
                </AppCheckBox>
            </VerticalGroup>
            
            <p><span class="text-red-600 text-xl">*</span>Pole jest wymagane.</p>
            <ConfirmButton class="shadow-xl">Zarejestruj się</ConfirmButton>
            <p class="text-center">
                <span>Masz już konto? </span>
                <NuxtLink :to="'/logowanie'" class="text-[#463691]">Zaloguj się</NuxtLink>
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
        title: 'Załóż konto | OTOSZROTO'
    });
</script>

<style scoped>

</style>