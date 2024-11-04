export default defineEventHandler(async (event) => {
    const body = await readBody(event);

    return {
        "value": "qweqwe"
    }
})