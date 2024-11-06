<template>
    <div>
        {{ value }}
    </div>
</template>

<script setup>
    const { value } = useRoute().params;
</script>