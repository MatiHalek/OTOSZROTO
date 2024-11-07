<template>
    <h1 class="font-semibold text-3xl text-center">
        Szukaj spośród
        <span class="font-extrabold text-[#E5A00A]">
            <div id="counter" class="inline-flex translate-y-0.5">
                <div
                v-for="(digit, index) in digits"
                :key="index"
                class="flex flex-col overflow-hidden h-9"
                :class="{
                    'ml-3': index % 3 === digits.length % 3
                }">
                    <div
                        v-for="n in 10"
                        :key="n"
                        class="h-10 text-4xl text-center"
                        :style="{
                        transform: `translateY(${-2.5 * digit}rem)`,
                        transition: `transform .${9 - index}s ease-in-out`
                        }">
                        {{ n - 1 }}
                    </div>
                </div>
            </div>
        </span>
        ogłoszeń
    </h1>
</template>

<script setup>
    const advertisementCount = ref(72450);
    const digits = ref([6, 5, 5, 0]);
    InitializeCounter();
    function InitializeCounter() {
    digits.value = advertisementCount.value
        .toString()
        .split("")
        .map(Number);
    }
    function UpdateCounter() {
    advertisementCount.value += Math.floor(Math.random() * 9) - 4;
    digits.value = advertisementCount.value
        .toString()
        .split("")
        .map(Number);
    }
    onMounted(() => {
    InitializeCounter();
    UpdateCounter();
    setInterval(UpdateCounter, 1500);
    });
</script>