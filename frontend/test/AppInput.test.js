/**
 * @vitest-environment happy-dom
 */

import { describe,expect,it } from "vitest";
import { mount } from "@vue/test-utils";
import AppInput  from "../components/inputs/AppInput.vue";


// tests for email input
describe('App email input tests', () => {
    it('should display error invalid email', async () => {
        const wrapper = mount(AppInput, {
            props: {
                type: 'email',
                validate: true
            }
        });
        const input = await wrapper.find('input[type="email"]')
    
        await input.setValue('testvaluethatsnotemail');
    
        expect(wrapper.find('p').text()).toEqual('Niepoprawny adres e-mail!');
    })

    it('should not display error', async () => {
        const wrapper = mount(AppInput, {
            props: {
                type: 'email',
                validate: true
            }
        });
        const input = await wrapper.find('input[type="email"]')
    
        await input.setValue('testemail@gmail.com');
    
        expect(wrapper.find('p').text()).toEqual('');
    })
});

// tests for phone number input
describe('App phone number input tests', () => {
    it('should display error invalid phone number', async () => {
        const wrapper = mount(AppInput, {
            props: {
                type: 'tel',
                validate: true
            }
        });
        const input = await wrapper.find('input[type="tel"]')
    
        await input.setValue('123456789');
    
        expect(wrapper.find('p').text()).toEqual('Niepoprawny numer telefonu!');
    })

    it('should not display error', async () => {
        const wrapper = mount(AppInput, {
            props: {
                type: 'tel',
                validate: true
            }
        });
        const input = await wrapper.find('input[type="tel"]')
    
        await input.setValue('123-456-789');
    
        expect(wrapper.find('p').text()).toEqual('');
    })
});

// tests for password input
describe('App password input tests', () => {
    it('should display error if password is too short ', async () => {
        const wrapper = mount(AppInput, {
            props: {
                type: 'password',
                validate: true
            }
        });
        const input = await wrapper.find('input[type="password"]')
    
        await input.setValue('qwerty'); // 6 characters
    
        expect(wrapper.find('p').text()).toEqual('Hasło musi mieć od 8 do 50 znaków!');
    })

    it('should display error if password is too long ', async () => {
        const wrapper = mount(AppInput, {
            props: {
                type: 'password',
                validate: true
            }
        });
        const input = await wrapper.find('input[type="password"]')
    
        await input.setValue('0TpeS2ccJFOMFVpPX2UuRdqKBm3XotYnPDluv7zhPVSpaGKIDAb'); // 51 characters
    
        expect(wrapper.find('p').text()).toEqual('Hasło musi mieć od 8 do 50 znaków!');
    })

    it('should not display error', async () => {
        const wrapper = mount(AppInput, {
            props: {
                type: 'password',
                validate: true
            }
        });
        const input = await wrapper.find('input[type="password"]')
    
        await input.setValue('qwertyuiop'); // 10 characters
    
        expect(wrapper.find('p').text()).toEqual('');
    })
});