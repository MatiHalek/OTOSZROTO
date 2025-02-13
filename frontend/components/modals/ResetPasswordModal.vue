<template>
    <Transition name="fade">
        <div class="fixed left-0 top-0 z-50 w-full h-full bg-[#00000095] flex justify-center items-center" v-show="isVisible">
            <Transition>
                <div class="bg-[#fff] dark:bg-black dark:text-white h-96 w-[500px] rounded-lg relative py-14 px-8 flex flex-col justify-between">
                    <div>
                        <h2 class="text-center font-bold text-3xl">Nie pamiętasz hasła?</h2>
                        <h3 class="text-center py-3 text-base">Na podany e-mail prześlemy link do zmiany hasła!</h3>

                        <input v-model="email" class="outline-none border-2 dark:bg-transparent w-full mt-8 p-2" type="text" placeholder="E-mail">
                        <div class="flex flex-col mt-10 gap-3">
                            <button class="w-full bg-[#E5A00A] p-2 text-[#FFF] rounded-full hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300" @click="sendEmail">Wyślij link</button>
                            <button @click="$emit('close')" class="w-full bg-[#DDD] dark:bg-[#333] p-2 rounded-full hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300">Anuluj</button>
                        </div>
                    </div>
                    <div v-if="messageVisible" class="absolute bottom-[.5rem] translate-y-[100%] left-0 w-full bg-green-600 text-white text-center py-2 font-semibold rounded-b-lg">
                        Link wysłany<br>
                        <small class="font-normal">Nie dotarł? Sprawdź poprawność e-mail i/lub wyślij ponownie.</small>
                    </div>
                </div>
            </Transition>
            
        </div>
    </Transition>
</template>

<script setup>
import { ref } from 'vue';

const props = defineProps(['isVisible']);
const email = ref('');
const messageVisible = ref(false);

async function sendEmail() {
    messageVisible.value = false;
    if (email.value.trim() !== '') {
        await $fetch(`http://localhost:5271/api/auth/reset/${email.value}`, {
            method: 'post'
        });
        messageVisible.value = true;
    }
}
</script>

<style scoped>
    .v-enter-active,
    .v-leave-active {
        transition: all .3s cubic-bezier(0.24,0.07,0.09,0.99);
    }

    .v-enter-from,
    .v-leave-to {
        transform: scale(.8);
        opacity: 0;
        transform-origin: center;
    }

    .fade-enter-active,
    .fade-leave-active {
        transition: opacity .3s cubic-bezier(0.24,0.07,0.09,0.99);
    }

    .fade-enter-from,
    .fade-leave-to {
        opacity: 0;
    }
</style>

