<template>
    <AppForm>
        <NuxtLink to="/" title="Strona główna OTOSZROTO" class="relative mx-auto mt-4">
            <div class="flex items-center gap-1 border-y-4 border-y-transparent hover:border-b-[#E5A00A] transition-all">           
                <img src="/img/logo.png" alt="Logo strony" width="50" height="50">
                <h1 class="text-2xl font-extrabold text-[#E5A00A]">
                    <span class="text-[#463691]">OTO</span>SZROTO
                </h1>                   
            </div>
        </NuxtLink>

        <VerticalGroup>
            <PageTitle>Załóż konto</PageTitle>
        </VerticalGroup>

        <VerticalGroup class="gap-y-6 relative overflow-auto grow px-10">     
            <VerticalGroup>
                <InputLabel for="registrationInputEmail" style="color: black">Adres e-mail<span class="text-red-600 text-xl">*</span></InputLabel>
                <AppInput @error-value="(value) => { errors.input1 = value }" v-model="newUserData.Email" :validate="true" type="email" id="registrationInputEmail" />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel for="registrationInputPhone" style="color: black">Numer telefonu<span class="text-red-600 text-xl">*</span></InputLabel>
                <AppInput @error-value="(value) => { errors.input2 = value }" v-model="newUserData.PhoneNumber" :validate="true" type="tel" id="registrationInputPhone" />
            </VerticalGroup>

            <VerticalGroup>
                <InputLabel for="registrationInputPassword" style="color: black">Hasło<span class="text-red-600 text-xl">*</span></InputLabel>
                <AppInput @error-value="(value) => { errors.input3 = value }" v-model="newUserData.Password" :validate="true" type="password" id="registrationInputPassword" />
            </VerticalGroup>

            <VerticalGroup>
                <VerticalGroup>
                    <InputLabel for="registrationInputPassword2" style="color: black">Powtórz hasło<span class="text-red-600 text-xl">*</span></InputLabel>
                    <AppInput @error-value="(value) => { errors.input4 = value }" v-model="Password2" :validate="true" type="password" id="registrationInputPassword2" />
                        <p class="relative left-0 -bottom-2 text-[#E32727] text-right">
                            {{ errorMessage }}
                        </p>
                </VerticalGroup>

                <AppCheckBox v-model="checkBoxSelected" @change="checkCheckbox()">
                    <span class="cursor-pointer select-none"  :class="{ 'text-red-600': error, 'text-black' :!error }">Oświadczam, że znam i akceptuję postanowienia serwisu OTOSZROTO. <a href="regulamin" target="_blank" class="font-bold transition-all hover:text-[#E5A00A]">(przeczytaj treść regulaminu)</a><span class="text-red-600 text-xl">*</span></span>
                </AppCheckBox>
            </VerticalGroup>

            <p><span class="text-red-600 text-xl">*</span>Pole jest wymagane.</p>
            <ConfirmButton class="shadow-xl mt-8" @click.prevent="registerUser()">Zarejestruj się</ConfirmButton>
            <p class="text-center">
                <span>Masz już konto? </span>
                <NuxtLink :to="'/logowanie'" class="text-[#463691]">Zaloguj się</NuxtLink>
            </p>          
        </VerticalGroup>
        <p class="relative border-t-4 text-center py-2 mt-3 rounded font-semibold">&copy; 2025 MH Corp.</p>
    </AppForm>
</template>

<script setup>
    definePageMeta({
        layout: 'clear'
    });
    useHead({
        title: 'Załóż konto | OTOSZROTO'
    });

    const user = useUserStore();

    onMounted(async () => {
        if(user.isLogged) {
            await navigateTo('/profil');
        }
    })

    const newUserData = ref({
        Email: '',
        PhoneNumber: '',
        Password: ''
    });

    const Password2 = ref('');
    const errorMessage = ref('');

    const errors = ref({
        input1: true,
        input2: true,
        input3: true,
        input4: true,
    });
    const checkBoxSelected = ref(false);
    const error = ref(false);
    const errorPassword = ref(false);

    function checkCheckbox() {
        if(checkBoxSelected.value == true) error.value = false;
    }

    async function registerUser() {
        if(checkBoxSelected.value == false) {
            error.value = true;
        }

        if(newUserData.value.Password != Password2.value) {
            errorPassword.value = true;
            errorMessage.value = 'Hasła muszą być identyczne!';
        } else {
            errorPassword.value = false;
            errorMessage.value = '';
        }

        if(!errors.value.input1 && !errors.value.input2 && !errors.value.input3 && !errors.value.input4 && checkBoxSelected.value == true && error.value == false && errorPassword.value == false) {
            const response = await $fetch('http://localhost:5271/api/auth/register', {
                method: 'POST',
                body: {
                    "name": '',
                    "surname": "",
                    "email": newUserData.value.Email,
                    "phoneNumber": newUserData.value.PhoneNumber,
                    "password": newUserData.value.Password
                }
            })

            if(response.userID) {
                await navigateTo('/logowanie');
            }
        }
    }
</script>

<style scoped>

</style>