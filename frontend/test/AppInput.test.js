/**
 * @vitest-environment happy-dom
 */

import { describe,expect,it } from "vitest";
import { mount } from "@vue/test-utils";
import AppInput  from "../components/inputs/AppInput.vue";

describe('App input tests', () => {
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