export default defineEventHandler(async (event) => {
    const body = await readBody(event);

    const response = await $fetch(`http://localhost:5271/api/advertisment/${body.id}`, 
    { 
        responseType: 'json', 
        method: 'get', 
    });

    return {
        'data': response
    }
})