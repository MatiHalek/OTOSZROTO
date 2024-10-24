<template>
    <AppForm>
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
                <InputLabel>Powtórz hasło:</InputLabel>
                <AppInput />
            </VerticalGroup>
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