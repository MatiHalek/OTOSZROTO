<template>
    <label :for="propFor" class="pb-2 text-[#332404] dark:text-white font-medium">
        <slot />
    </label>
</template>

<script setup>
    defineProps(['propFor']);
</script>