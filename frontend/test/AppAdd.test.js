

/**
 * @vitest-environment happy-dom
 */

import { describe,expect,it } from "vitest";
import { mount } from "@vue/test-utils";
import AppCheckBox  from "../components/inputs/AppCheckBox.vue";


// tests for checkbox value input
describe('App checkbox value tests', () => {
    it('should display true', async () => {
        const wrapper = mount(AppCheckBox, {
            
        });
        const checkbox = await wrapper.find('input[type="checkbox"]')
    
        await checkbox.setValue(true);
    
        expect(wrapper.find('h2').text()).toEqual('true');
    })

});

