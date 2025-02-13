<template>
    <input 
        :type="type"
        :min="min"
        :max="max"
        v-model="inputValue" required
        class="rounded-lg outline-none border-[#DDD] border-2 w-full p-1 h-10 dark:bg-transparent">
</template>

<script setup>
    const inputValue = defineModel();
    defineProps({
        type: {
            type: String,
            default: 'text',
        },
        min: [String, Number], 
        max: [String, Number],
        step: [String, Number]
    });
</script>