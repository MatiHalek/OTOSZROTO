<template>
    <label :for="for" class="pb-2 text-[#332404]">
        <slot />
    </label>
</template>

<script setup>
    defineProps(['for']);
</script>